browseObsoleteReferences   "Smalltalk browseObsoleteReferences"
	| references |
	references _ OrderedCollection new.
	(Association allSubInstances select:
		[:x | ((x value isKindOf: Behavior) and: ['AnOb*' match: x value name]) or:
		['AnOb*' match: x value class name]]) 
		do: [:x | references addAll: (Smalltalk allCallsOn: x)].
	Smalltalk browseMessageList: references name: 'References to Obsolete Classes'