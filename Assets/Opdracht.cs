/*
 * 1. Voeg een hexagon toe die de ICollectable interface implementeert 
 * 
 * 2. Maak een interface IChangableColor, met de functies
 *    GetColor en SetColor
 * 
 * 3. Voeg deze interface ook toe aan je hexagon
 * 
 * 4. Maak een singleton class ColorManager. Net zoals de CollectableManager
 *    moet deze een lijst van objecten in het spel bijhouden.
 *    
 * 5. Zorg dat de hexagons niet enkel in de CollectableManager terechtkomen, maar 
 *    ook in de ColorManager.
 *    
 * 6. De ColorManager moet elke 5 seconden de kleur van zijn objecten aanpassen. Hier wissel je
 *    tussen groen en rood.
 *    
 * 7. De scoremanager heeft een property 'MaxItems' die bepaalt hoeveel collectables van elk type
 *    er in het spel mogen zijn. Als je een object opraapt dat ook de interface IChangableColor heeft,
 *    dan kijk je naar de huidige kleur. Is die groen, dan verhoog je MaxItems met 1. Raap je het object 
 *    op wanneer het rood is, dan verlaag je MaxItems met 1.
 * */