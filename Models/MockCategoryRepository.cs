namespace sistema_restaurante.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Platos Principales", Description="Nuestra selección de cortes premium y sabores amazónicos."},
                new Category{CategoryId=2, CategoryName="Entradas", Description="Para comenzar tu experiencia a la brasa."},
                new Category{CategoryId=3, CategoryName="Bebidas y Coctelería", Description="Maridaje perfecto con esencia cruceña."},
                new Category{CategoryId=4, CategoryName="Postres", Description="El cierre dulce y artesanal de tu visita."}
            };
    }
}
