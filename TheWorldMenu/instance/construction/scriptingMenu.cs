scriptingMenu
        "Build the scripting menu for the world."

        ^ self fillIn: (self menu: 'authoring tools...') from: { 
                { 'standard parts bin' . { self . #createStandardPartsBin}. 'A bin of standard parts, from which you can drag out useful morphs.'}.
                { 'custom parts bin' . { self . #launchCustomPartsBin}. 'A customized bin of parts.  To define what the custom parts bin is, edit any existing parts bin and tell it to be saved as the custom parts bin.'}.
                { 'view trash contents' . { #myWorld . #openScrapsBook:}. 'The place where all your trashed morphs go.'}.
                { 'empty trash can' . { Utilities . #emptyScrapsBook}. 'Empty out all the morphs that have accumulated in the trash can.'}.
			nil.
                { 'new scripting area' . { #myWorld . #detachableScriptingSpace}. 'A window set up for simple scripting.'}.
			 { 'summary of scripts' . {#myWorld . #printScriptSummary}. 'Produces a summary of scripted objects in the project, and all of their scripts.'}.
			 { 'status of scripts' . {#myWorld . #showStatusOfAllScripts}. 'Lets you view the status of all the scripts belonging to all the scripted objects of the project.'}.
                nil.
                { 'unlock locked objects' . { #myWorld . #unlockContents}. 'If any items on the world desktop are currently locked, unlock them.'}.
                { 'unhide hidden objects' . { #myWorld . #showHiders}. 'If any items on the world desktop are currently hidden, make them visible.'}.
        }