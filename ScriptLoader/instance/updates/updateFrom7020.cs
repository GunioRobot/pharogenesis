updateFrom7020
	"self new updateFrom7020"
	"
	- 0003215: saving and reloading a string morph with a true type font breaks the font
	- 0003354: Can't select some colors in PaintBoxColorPicker
	- 0003355: [BUG] Fresh 3.9a image (build 7020) has text morphs in objects window wrong size
	- added CollectionsTests from stef
	- OmniBrowser (fixed by Lukas)
		- makes it possible to drag meta-classes to new categories
		- add missing OBClassActor to OBMetaclassNode
		- fix as published in http://bugs.impara.de/view.php?id=3269
		- fix a debugger when selecting omnibrowser as default browser 
		- made the buttons in omnibrowser look like they do in 3.9
		- fixes an infinite recursion occuring when a drag&drop operation is started
	- fix for the SlowRedraw bug (Adrian)
	- valueWithExit for BlockContex / BlockClosure
	- added Symbol>>#value:
	-------
	Change Set:		SuperSwikiFixKR
	Date:			20 February 2006
	Author:			Korakurider

	A one-method fix to the recent SuperSwikiStr update.
	-------
	Change Set:		TTCFont-fix-ascent-jrp
	Date:			27 March 2006
	Author:			John Pierce

	Add ascent instance variable back to the class so method ascent will work again.
	"
	
	self script55.
	self flushCaches.
	MCDefinition clearInstances.