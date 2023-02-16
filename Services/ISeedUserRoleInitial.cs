namespace EcommerceMVC.Services {
    public interface ISeedUserRoleInitial {
        //Metodo para implementação dos perfis
        void SeedRoles();
        //Metodo para criar e atribuir os usuários
        void SeedUsers();
    }
}
