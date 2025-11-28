
"use client";

import Link from "next/link";
import { usePathname } from "next/navigation";
import { Film, Search, User } from "lucide-react";

export default function Navbar() {
  const pathname = usePathname();

  const navItems = [
    { name: "Home", href: "/" },
    { name: "Films", href: "/films" },
    { name: "Séries", href: "/series" },
    { name: "Nouveautés", href: "/new" },
    { name: "Ma liste", href: "/my-list" },
    { name: "À propos", href: "/about-us" },
  ];

  return (
    <header className="fixed top-0 left-0 right-0 z-50 bg-black/95 backdrop-blur-md border-b border-white/10">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex items-center justify-between h-16">
          {/* Logo */}
          <Link href="/" className="flex items-center gap-2 group">
            <Film className="w-10 h-10 text-red-600 group-hover:text-red-500 transition" />
            <span className="text-2xl font-bold text-white tracking-tighter">
              Film<span className="text-red-600">Shop</span>
            </span>
          </Link>

          {/* Navigation centrale */}
          <nav className="hidden md:flex items-center gap-8">
            {navItems.map((item) => {
              const isActive = pathname === item.href;
              return (
                <Link
                  key={item.href}
                  href={item.href}
                  className={`relative px-1 py-2 text-sm font-medium transition-all duration-300
                    ${isActive 
                      ? "text-white after:absolute after:bottom-0 after:left-0 after:right-0 after:h-0.5 after:bg-red-600" 
                      : "text-gray-300 hover:text-white"
                    }`}
                >
                  {item.name}
                  {isActive && (
                    <span className="absolute -bottom-1 left-0 right-0 h-1 bg-red-600 rounded-full" />
                  )}
                </Link>
              );
            })}
          </nav>

          {/* Actions droite */}
          <div className="flex items-center gap-4">
            {/* Search */}
            <button className="p-2 hover:bg-white/10 rounded-lg transition">
              <Search className="w-5 h-5 text-white" />
            </button>

            {/* Profil / Login */}
            <button className="flex items-center gap-2 bg-red-600 hover:bg-red-700 px-5 py-2.5 rounded-lg font-medium transition shadow-lg hover:shadow-red-600/25">
              <User className="w-4 h-4" />
              <span>Se connecter</span>
            </button>
          </div>
        </div>
      </div>

      {/* Mobile menu (optionnel, tu peux ajouter un drawer plus tard) */}
    </header>
  );
}