using System.IO;
using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using juego;

//---API----
List<Caracther> personajesGot = funciones.DescargarApi();
    
//------INICIALIZANDO
List<personajes> Personajes = funciones.crearLista(personajesGot);
//hasta aca todo bien 

//--------FILES JSON--------
//falta lo de si existe un json usarlo
funciones.CrearFileJson(Personajes);


//-----COMBATE-----
//fijarme si esta bien la cantidad de combates
//revisar las formulas de los ataques
//revisar el remove de la lista cuando pierde
//de ahi en mas creo que todo bien
funciones.Combate(Personajes);

//-------FILES-------------
funciones.CrearFileCSV(Personajes);











