supplementaryPartsDescriptions
	"Answer a list of DescriptionForPartsBin objects that characterize objects that this class wishes to contribute to Stationery bins *other* than by the standard default #newStandAlone protocol"

	^ {	DescriptionForPartsBin
			formalName: 'Status'
			categoryList: #(Scripting)
			documentation: 'Buttons to run, stop, or single-step scripts'
			globalReceiverSymbol: #ScriptingSystem
			nativitySelector: #scriptControlButtons.
		DescriptionForPartsBin
			formalName: 'Scripting'
			categoryList: #(Scripting)
			documentation: 'A confined place for drawing and scripting, with its own private stop/step/go buttons.'
			globalReceiverSymbol: #ScriptingSystem
			nativitySelector: #newScriptingSpace.
		DescriptionForPartsBin
			formalName: 'Random'
			categoryList: #(Scripting)
			documentation: 'A tile that will produce a random number in a given range'
			globalReceiverSymbol: #RandomNumberTile
			nativitySelector: #new.
		DescriptionForPartsBin
			formalName: 'ButtonDown?'
			categoryList: #(Scripting)
			documentation: 'Tiles for querying whether the mouse button is down'
			globalReceiverSymbol: #ScriptingSystem
			nativitySelector: #anyButtonPressedTiles.
		DescriptionForPartsBin
			formalName: 'ButtonUp?'
			categoryList: #(Scripting)
			documentation: 'Tiles for querying whether the mouse button is up'
			globalReceiverSymbol: #ScriptingSystem
			nativitySelector: #noButtonPressedTiles.
		DescriptionForPartsBin
			formalName: 'NextPage'
			categoryList: #(Presentation)
			documentation: 'A button which, when clicked, takes the reader to the next page of a book'
			globalReceiverSymbol: #BookMorph
			nativitySelector: #nextPageButton.
		DescriptionForPartsBin
			formalName: 'PreviousPage'
			categoryList: #(Presentation)
			documentation: 'A button which, when clicked, takes the reader to the next page of a book'
			globalReceiverSymbol: #BookMorph
			nativitySelector: #previousPageButton.},

	(Flaps quadsDefiningToolsFlap collect:
		[:aQuad | DescriptionForPartsBin fromQuad: aQuad categoryList: #(Tools)])