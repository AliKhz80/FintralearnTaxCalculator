using AutoMapper;
using System.Collections.Generic;

namespace Application.Extentions.AutoMapper
{
    public class AutoMapperExtention<Tsource, Tdestination>
    {

        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring Tsource and Tdestination
                cfg.CreateMap<Tsource, Tdestination>();
                //Any Other Mapping Configuration ....
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }

        public static Mapper InitializeAutomapperList()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring Tsource and Tdestination
                cfg.CreateMap<List<Tsource>,List<Tdestination>>();
                //Any Other Mapping Configuration ....
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }


    }
}
