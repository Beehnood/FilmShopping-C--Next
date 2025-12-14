
import { EMOJIS } from '@/components/Emoji';
import Image from 'next/image';
import Link from 'next/link';


export interface IGetProducts {
  id: number;
  name?: string;
  original_name?: string;
  overview: string;
  first_air_date?: string;
  vote_average: number;
  poster_path: string | null;
  popularity: number;
  vote_count: number;
  origin_country: string[];
  original_language: string;
}

interface ApiResponse {
  page: number;
  results: IGetProducts[];
  total_pages: number;
  total_results: number;
}


export default async function Series() {
  const res = await fetch("https://api.themoviedb.org/3/tv/changes?page=1", {
    cache: "no-store",
  });

  // Protection si l’API plante
  if (!res.ok) {
    return (
      <div className="min-h-screen bg-black text-white flex items-center justify-center text-3xl">
        Impossible de charger les séries...
      </div>
    );
  }

  const data: ApiResponse = await res.json();

  return (
    <section className="min-h-screen bg-black text-white pt-24 pb-16">
      <div className="max-w-7xl mx-auto px-6">
        <h1 className="text-6xl font-bold text-center mb-12 bg-gradient-to-r from-purple-600 to-pink-600 bg-clip-text text-transparent">
          Séries Populaires {EMOJIS.TV}
        </h1>

        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-5 gap-8">
          {data.results.map((series) => (
            <Link href={`/series/${series.id}`} key={series.id} className="group block">
              <article className="relative overflow-hidden rounded-2xl bg-gray-800 shadow-xl transition-all duration-500 hover:scale-105 hover:shadow-2xl hover:shadow-purple-600/30">
                
                {series.poster_path ? (
                  <Image
                    src={`https://image.tmdb.org/t/p/w500${series.poster_path}`}
                    alt={series.name || series.original_name || "Série"}
                    width={500}
                    height={750}
                    className="w-full h-full object-cover transition-transform duration-500 group-hover:scale-110"
                    placeholder="blur"
                    blurDataURL="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mN8/+F9PwAI8wNPvd7POQAAAABJRU5ErkJggg=="
                  />
                ) : (
                  <div className="bg-gray-700 border-2 border-dashed w-full h-96 flex items-center justify-center text-gray-500">
                    No Image
                  </div>
                )}

                <div className="absolute inset-0 bg-gradient-to-t from-black via-black/70 to-transparent opacity-90" />

                <div className="absolute bottom-0 left-0 right-0 p-5 text-white">
                  <h3 className="text-lg font-bold line-clamp-2 mb-2">
                    {series.name || series.original_name || "Sans titre"}
                  </h3>

                  <div className="flex items-center gap-3 text-sm">
                    <span className="bg-yellow-500 text-black px-3 py-1 rounded-full font-bold flex items-center gap-1">
                      {EMOJIS.STAR} {series.vote_average.toFixed(1)}
                    </span>
                    <span className="text-gray-300">
                      {series.vote_count.toLocaleString()} votes
                    </span>
                  </div>

                  {series.first_air_date && (
                    <p className="text-gray-400 text-xs mt-2">
                      {EMOJIS.CALENDAR} {new Date(series.first_air_date).getFullYear()}
                    </p>
                  )}

                  <div className="absolute top-3 right-3 bg-red-600 px-3 py-1 rounded-full text-xs font-bold flex items-center gap-1">
                    {EMOJIS.FIRE} {Math.round(series.popularity)}
                  </div>
                </div>

                {/* Hover description */}
                <div className="absolute inset-0 bg-black/90 opacity-0 group-hover:opacity-100 transition-opacity duration-300 p-6 flex flex-col justify-end">
                  <p className="text-sm line-clamp-4 text-gray-200">
                    {series.overview || "Aucune description disponible."}
                  </p>
                  <div className="mt-3 flex flex-wrap gap-2">
                    <span className="text-xs bg-blue-600 px-2 py-1 rounded">
                      {(series.original_language || "en").toUpperCase()}
                    </span>
                    {(series.origin_country ?? []).slice(0, 2).map((c) => (
                      <span key={c} className="text-xs bg-green-600 px-2 py-1 rounded">
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