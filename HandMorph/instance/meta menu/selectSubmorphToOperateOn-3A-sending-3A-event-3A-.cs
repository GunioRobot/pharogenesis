selectSubmorphToOperateOn: rootMorph sending: aSymbol event: evt
	"Let the user select a submorph of the given root morph. When selected, the given selector is sent with the selected submorph as an argument."

	| possibleTargets menu |
	possibleTargets _ rootMorph morphsAt: targetOffset.
	possibleTargets size = 1 ifTrue: [^ self perform: aSymbol with: possibleTargets first].
	menu _ MenuMorph new.
	possibleTargets do: [:m |
		menu add: (self submorphNameFor: m)
			target: self
			selector: aSymbol
			argumentList: (Array with: m with: evt)].
	menu popUpAt: self position event: evt.
