againOrSame: bool 
	| bk keys |
	(bk := morph ownerThatIsA: BookMorph) ifNotNil: 
			[(keys := bk valueOfProperty: #tempSearchKey ifAbsent: [nil]) ifNil: 
					["Cmd-f"

					keys := bk valueOfProperty: #searchKey ifAbsent: [nil]	"Cmd-g"]
				ifNotNil: [bk removeProperty: #tempSearchKey].
			keys ifNotNil: 
					[keys notEmpty
						ifTrue: 
							[bk findText: keys.
							^(morph respondsTo: #editView) 
								ifTrue: [morph editView selectionInterval: self selectionInterval]]]].
	super againOrSame: bool.
	(morph respondsTo: #editView) 
		ifTrue: [morph editView selectionInterval: self selectionInterval]