using juego;
using System.IO;

//------INICIALIZANDO
List<personajes> Personajes = funciones.crearLista();
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











