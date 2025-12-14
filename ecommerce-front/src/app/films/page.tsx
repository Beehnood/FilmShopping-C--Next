import { EMOJIS } from "@/components/Emoji";
import Image from "next/image";
import Link from "next/link";

export interface IGetProducts {
  id: number;
  name: string;
  original_name: string;
  overview: string;
  first_air_date: string;
  vote_average: number;
  poster_path: string | null;
  backdrop_path: string | null;
  popularity: number;
  vote_count: number;
  genre_ids: number[];
  origin_country: string[];
  original_language: string;
}

interface ApiResponse {
  page: number;
  results: IGetProducts[];
  total_pages: number;
  total_results: number;
}

// Server Component par défaut → pas besoin de "use client"
export default async function FilmsPage() {
  // Récupération directe côté serveur (plus rapide + SEO + SSG possible)
  const res = await fetch("http://localhost:5086/api/tmdb/popular?page=1", {
    next: { revalidate: 3600 }, // revalidate toutes les heures (ou 0 pour SSR pur)
  });

  if (!res.ok) {
    return (
      <div className="text-center text-red-500 text-2xl mt-20">
        Erreur de chargement des films...
      </div>
    );
  }

  const data: ApiResponse = await res.json();

  return (
    <section className="min-h-screen bg-linear-to-b from-black via-gray-900 to-black pt-24 pb-16">
      <div className="max-w-7xl mx-auto px-4">
        <h1 className="text-5xl md:text-6xl font-bold text-center text-white mb-12 bg-clip-text text-transparent bg-linear-to-r from-red-600 to-pink-600">
          Films & Séries Populaires
        </h1>

        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-5 gap-8">
          {data.results.map((film) => (
            <Link
              href={`/films/${film.id}`}
              key={film.id}
              className="group block"
            >
              <article className="relative overflow-hidden rounded-2xl bg-gray-800 shadow-xl transition-all duration-500 hover:scale-105 hover:shadow-2xl hover:shadow-red-600/20">
                {/* Image optimisée avec Next/Image */}
                {film.poster_path ? (
                  <Image
                    src={`https://image.tmdb.org/t/p/w500${film.poster_path}`}
                    alt={film.name || film.original_name}
                    width={500}
                    height={750}
                    className="w-full h-full object-cover transition-transform duration-500 group-hover:scale-110"
                    placeholder="blur"
                    blurDataURL="/placeholder.jpg" // tu peux mettre une image basse rés au public/
                  />
                ) : (
                  <div className="bg-gray-700 border-2 border-dashed border-gray-600 w-full h-96 flex items-center justify-center">
                    <span className="text-gray-500">No Image</span>
                  </div>
                )}

                {/* Overlay gradient */}
                <div className="absolute inset-0 bg-linear-to-b from-black via-black/70 to-transparent opacity-90" />

                {/* Contenu */}
                <div className="absolute bottom-0 left-0 right-0 p-5 text-white">
                  <h3 className="text-lg font-bold line-clamp-2 mb-2">
                    {film.name || film.original_name}
                  </h3>

                  <div className="flex items-center gap-3 text-sm">
                    <span className="bg-yellow-500 text-black px-3 py-1 rounded-full font-bold flex items-center gap-1">
                      {EMOJIS.STAR} {film.vote_average.toFixed(1)}
                    </span>
                    <span className="text-gray-300">
                      {film.vote_count.toLocaleString()} votes
                    </span>
                  </div>

                  <p className="text-gray-400 text-xs mt-2">
                    {EMOJIS.CALENDAR}{" "}
                    {new Date(film.first_air_date).getFullYear()}
                  </p>

                  {/* Popularité badge */}
                  <div className="absolute top-3 right-3 bg-red-600 px-3 py-1 rounded-full text-xs font-bold flex items-center gap-1">
                    {EMOJIS.FIRE} {Math.round(film.popularity)}
                  </div>
                </div>

                {/* Hover : aperçu description */}
                <div className="absolute inset-0 bg-black/80 opacity-0 group-hover:opacity-100 transition-opacity duration-300 p-6 flex flex-col justify-end">
                  <p className="text-sm line-clamp-4 text-gray-200">
                    {film.overview || "Aucune description disponible."}
                  </p>
                  <div className="mt-3 flex flex-wrap gap-2">
                    <span className="text-xs bg-blue-600 px-2 py-1 rounded">
                      {film.original_language.toUpperCase()}
                    </span>
                    {(film.origin_country ?? []).slice(0, 2).map((c) => (
                      <span
                        key={c}
                        className="text-xs bg-green-600 px-2 py-1 rounded"
                      >
                        {c}
                      </span>
                    ))}
                  </div>
                </div>
              </article>
            </Link>
          ))}
        </div>
      </div>
    </section>
  );
}
