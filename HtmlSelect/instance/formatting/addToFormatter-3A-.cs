addToFormatter: formatter
	| options defaultOption listMorph names size valueHolder |
	formatter currentFormData ifNil: [
		"not in a form.  It's bogus HTML but try to survive"
		^self ].

	names _ OrderedCollection new.
	options _ OrderedCollection new.
	defaultOption _ nil.

	(self getAttribute: 'multiple') ifNotNil: [
		self flag: #incomplete.
		formatter addString: '[M option list]'.
		^self ].

	contents do: [ :c |  c isOption ifTrue: [
		names add: c value.
		options add: c label withBlanksCondensed.
		(c getAttribute: 'selected') ifNotNil: [ defaultOption _ c label ] ] ].

	contents isEmpty ifTrue: [ ^self ].

	defaultOption ifNil: [ defaultOption _ options first ].

	size _ (self getAttribute: 'size' default: '1') asNumber.
	size = 1
		ifTrue: [listMorph _ DropDownChoiceMorph new initialize; contents: defaultOption.
			listMorph items: options; target: nil; getItemsSelector: nil;
				maxExtent: options; border: #useBorder]
		ifFalse: [valueHolder _ ValueHolder new contents: (contents indexOf: defaultOption).
			listMorph _ PluggableListMorph on: valueHolder list: nil
				selected: #contents  changeSelected: #contents:.
			listMorph list: options.
			listMorph extent: ((listMorph extent x) @ (listMorph scrollDeltaHeight * size))].

	formatter addMorph: listMorph.

	formatter currentFormData addInput:
		(SelectionInput  name: self name  defaultValue: defaultOption
			list: listMorph  values: names asArray)