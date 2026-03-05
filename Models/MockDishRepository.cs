namespace sistema_restaurante.Models
{
    public class MockDishRepository : IDishRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Dish> AllDishes =>
            new List<Dish>
            {
                // Platos Principales
                new Dish { 
                    DishId = 1, Name = "Lomito a la Parrilla", Price = 95M, 
                    ShortDescription = "Corte premium con puré rústico", 
                    LongDescription = "Lomito de res a la parrilla, acompañado de puré rústico de yuca y vegetales grillados.", 
                    Category = _categoryRepository.AllCategories.ElementAt(0), 
                    ImageUrl = "/images/lomito_v2.png", 
                    ImageThumbnailUrl = "/images/lomito_v2.png", 
                    InStock = true, IsDishOfTheWeek = true 
                },
                new Dish { 
                    DishId = 2, Name = "Pacú a la Mantequilla de Hierbas Amazónicas", Price = 88M, 
                    ShortDescription = "Pescado de río con risotto de quinua", 
                    LongDescription = "Filete de pacú fresco bañado en mantequilla de hierbas de la Amazonía, servido con risotto cremoso de quinua blanca.", 
                    Category = _categoryRepository.AllCategories.ElementAt(0), 
                    ImageUrl = "/images/pacu_v2.png", 
                    ImageThumbnailUrl = "/images/pacu_v2.png", 
                    InStock = true, IsDishOfTheWeek = false 
                },
                new Dish { 
                    DishId = 3, Name = "Cordero en Cocción Lenta con Salsa de Tamarindo", Price = 110M, 
                    ShortDescription = "Tierna carne con puré de camote", 
                    LongDescription = "Cordero braseado por horas en su jugo con salsa reducida de tamarindo, puré de camote ahumado y vegetales baby.", 
                    Category = _categoryRepository.AllCategories.ElementAt(0), 
                    ImageUrl = "/images/cordero_v2.png", 
                    ImageThumbnailUrl = "/images/cordero_v2.png", 
                    InStock = true, IsDishOfTheWeek = false 
                },
                new Dish { 
                    DishId = 4, Name = "Majadito de Autor (Charque Premium)", Price = 78M, 
                    ShortDescription = "Gourmet oriental con huevo poché", 
                    LongDescription = "Versión gourmet del clásico cruceño, con arroz aromático, charque premium, huevo poché y plátano caramelizado.", 
                    Category = _categoryRepository.AllCategories.ElementAt(0), 
                    ImageUrl = "/images/majadito_v2.png", 
                    ImageThumbnailUrl = "/images/majadito_v2.png", 
                    InStock = true, IsDishOfTheWeek = true 
                },

                // Entradas
                new Dish { 
                    DishId = 5, Name = "Tartar de Lomito Cruceño", Price = 48M, 
                    ShortDescription = "Lomito fino cortado a cuchillo", 
                    LongDescription = "Lomito fino cortado a cuchillo, aceite de oliva infusionado, alcaparras y crocante artesanal.", 
                    Category = _categoryRepository.AllCategories.ElementAt(1), 
                    ImageUrl = "/images/tartar.png", 
                    ImageThumbnailUrl = "/images/tartar.png", 
                    InStock = true, IsDishOfTheWeek = false 
                },
                new Dish { 
                    DishId = 6, Name = "Carpaccio de Pacú Amazónico", Price = 52M, 
                    ShortDescription = "Reducción cítrica y brotes orgánicos", 
                    LongDescription = "Láminas finas de pacú fresco, reducción cítrica y brotes orgánicos.", 
                    Category = _categoryRepository.AllCategories.ElementAt(1), 
                    ImageUrl = "/images/carpaccio.png", 
                    ImageThumbnailUrl = "/images/carpaccio.png", 
                    InStock = true, IsDishOfTheWeek = false 
                },
                new Dish { 
                    DishId = 7, Name = "Provoleta con Miel de Caña y Almendras", Price = 44M, 
                    ShortDescription = "Queso fundido dulce-salado", 
                    LongDescription = "Queso fundido artesanal con un toque cruceño dulce-salado de miel de caña y almendras tostadas.", 
                    Category = _categoryRepository.AllCategories.ElementAt(1), 
                    ImageUrl = "/images/provoleta.png", 
                    ImageThumbnailUrl = "/images/provoleta.png", 
                    InStock = true, IsDishOfTheWeek = false 
                },
                new Dish { 
                    DishId = 8, Name = "Mini Empanadas de Yuca Rellenas de Queso Menonita", Price = 40M, 
                    ShortDescription = "Sabor tradicional con queso menonita", 
                    LongDescription = "Deliciosas mini empanadas de yuca crujientes rellenas de auténtico queso menonita fundido.", 
                    Category = _categoryRepository.AllCategories.ElementAt(1), 
                    ImageUrl = "/images/empanaditas.png", 
                    ImageThumbnailUrl = "/images/empanaditas.png", 
                    InStock = true, IsDishOfTheWeek = false 
                },

                // Bebidas y Coctelería
                new Dish { 
                    DishId = 9, Name = "Cóctel “Atardecer Cruceño”", Price = 38M, 
                    ShortDescription = "Singani premium y maracuyá", 
                    LongDescription = "Mezcla de Singani premium, maracuyá fresco y un refrescante toque de menta.", 
                    Category = _categoryRepository.AllCategories.ElementAt(2), 
                    ImageUrl = "/images/coctel_atardecer.png", 
                    ImageThumbnailUrl = "/images/coctel_atardecer.png", 
                    InStock = true, IsDishOfTheWeek = false 
                },
                new Dish { 
                    DishId = 10, Name = "Spritz Tropical", Price = 42M, 
                    ShortDescription = "Espumante, mango y bitter", 
                    LongDescription = "Espumante seco combinado con puré de mango natural y bitter artesanal de la casa.", 
                    Category = _categoryRepository.AllCategories.ElementAt(2), 
                    ImageUrl = "/images/spritz.png", 
                    ImageThumbnailUrl = "/images/spritz.png", 
                    InStock = true, IsDishOfTheWeek = false 
                },
                new Dish { 
                    DishId = 11, Name = "Carta de Vinos Especial", Price = 0M, 
                    ShortDescription = "Sudamericanos seleccionados", 
                    LongDescription = "Selección especial de bodegas sudamericanas (Consulte nuestra carta premium).", 
                    Category = _categoryRepository.AllCategories.ElementAt(2), 
                    ImageUrl = "https://images.pexels.com/photos/1107005/pexels-photo-1107005.jpeg", 
                    ImageThumbnailUrl = "https://images.pexels.com/photos/1107005/pexels-photo-1107005.jpeg", 
                    InStock = true, IsDishOfTheWeek = false 
                },

                // Postres
                new Dish { 
                    DishId = 12, Name = "Mousse de Copoazú con Tierra de Cacao", Price = 38M, 
                    ShortDescription = "Delicia amazónica y cacao", 
                    LongDescription = "Suave mousse de copoazú sobre una cama de 'tierra' de cacao puro al 70%.", 
                    Category = _categoryRepository.AllCategories.ElementAt(3), 
                    ImageUrl = "/images/mousse.png", 
                    ImageThumbnailUrl = "/images/mousse.png", 
                    InStock = true, IsDishOfTheWeek = false 
                },
                new Dish { 
                    DishId = 13, Name = "Cheesecake de Maracuyá con Base de Castaña", Price = 36M, 
                    ShortDescription = "Cremoso con toque de castaña", 
                    LongDescription = "Cheesecake frío de maracuyá sobre una base crocante de castaña de la Amazonía.", 
                    Category = _categoryRepository.AllCategories.ElementAt(3), 
                    ImageUrl = "/images/cheesecake.png", 
                    ImageThumbnailUrl = "/images/cheesecake.png", 
                    InStock = true, IsDishOfTheWeek = false 
                },
                new Dish { 
                    DishId = 14, Name = "Helado Artesanal de Canela con Crocante de Almendra", Price = 32M, 
                    ShortDescription = "Helado de canela y almendras", 
                    LongDescription = "Helado preparado artesanalmente con canela de Ceilán y servido con crocante de almendras.", 
                    Category = _categoryRepository.AllCategories.ElementAt(3), 
                    ImageUrl = "https://images.pexels.com/photos/1352251/pexels-photo-1352251.jpeg", 
                    ImageThumbnailUrl = "https://images.pexels.com/photos/1352251/pexels-photo-1352251.jpeg", 
                    InStock = true, IsDishOfTheWeek = false 
                }
            };

        public IEnumerable<Dish> DishesOfTheWeek => AllDishes.Where(p => p.IsDishOfTheWeek);

        public Dish? GetDishById(int dishId) => AllDishes.FirstOrDefault(p => p.DishId == dishId);
    }
}
