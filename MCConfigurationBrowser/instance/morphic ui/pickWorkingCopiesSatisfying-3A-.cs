pickWorkingCopiesSatisfying: aBlock
	| copies item |
	copies := (MCWorkingCopy allManagers select: aBlock)
		asSortedCollection: [:a :b | a packageName <= b packageName].
	item := (PopUpMenu labelArray: #('match ...'),(copies collect: [:ea | ea packageName]) lines: #(1))
				startUpWithCaption: 'Package:'.
	item = 1 ifTrue: [
		| pattern |
		pattern := FillInTheBlank request: 'Packages matching:' initialAnswer: '*'.
		^pattern isEmptyOrNil
			ifTrue: [#()]
			ifFalse: [
				(pattern includes: $*) ifFalse: [pattern := '*', pattern, '*'].
				copies select: [:ea | pattern match: ea packageName]]
	].
	^ item = 0
		ifTrue: [#()]
		ifFalse: [{copies at: item - 1}]