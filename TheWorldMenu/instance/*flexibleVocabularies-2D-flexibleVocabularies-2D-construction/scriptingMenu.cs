scriptingMenu
	"Build the authoring-tools menu for the world."

	^ self fillIn: (self menu: 'authoring tools...') from: { 
		{ 'objects (o)' . { #myWorld . #activateObjectsTool }. 'A searchable source of new objects.'}.
		nil.  "----------"
 		{ 'view trash contents' . { #myWorld . #openScrapsBook:}. 'The place where all your trashed morphs go.'}.
 		{ 'empty trash can' . { Utilities . #emptyScrapsBook}. 'Empty out all the morphs that have accumulated in the trash can.'}.
		nil.  "----------"		

	{ 'new scripting area' . { #myWorld . #detachableScriptingSpace}. 'A window set up for simple scripting.'}.

		nil.  "----------"		
	
		{ 'status of scripts' . {#myWorld . #showStatusOfAllScripts}. 'Lets you view the status of all the scripts belonging to all the scripted objects of the project.'}.
		{ 'summary of scripts' . {#myWorld . #printScriptSummary}. 'Produces a summary of scripted objects in the project, and all of their scripts.'}.
		{ 'browser for scripts' . {#myWorld . #browseAllScriptsTextually}. 'Allows you to view all the scripts in the project in a traditional programmers'' "browser" format'}.


		nil.

		{ 'gallery of players' . {#myWorld . #galleryOfPlayers}. 'A tool that lets you find out about all the players used in this project'}.

"		{ 'gallery of scripts' . {#myWorld . #galleryOfScripts}. 'Allows you to view all the scripts in the project'}."

		{ 'etoy vocabulary summary' . {#myWorld . #printVocabularySummary }. 'Displays a summary of all the pre-defined commands and properties in the pre-defined EToy vocabulary.'}.

		{ 'attempt misc repairs' . {#myWorld . #attemptCleanup}. 'Take measures that may help fix up some things about a faulty or problematical project.'}.

		{ 'remove all viewers' . {#myWorld . #removeAllViewers}. 'Remove all the Viewers from this project.'}.

		{ 'refer to masters' . {#myWorld . #makeAllScriptEditorsReferToMasters }. 'Ensure that all script editors are referring to the first (alphabetically by external name) Player of their type' }.

		nil.  "----------" 

		{ 'unlock locked objects' . { #myWorld . #unlockContents}. 'If any items on the world desktop are currently locked, unlock them.'}.
		{ 'unhide hidden objects' . { #myWorld . #showHiders}. 'If any items on the world desktop are currently hidden, make them visible.'}.
        }