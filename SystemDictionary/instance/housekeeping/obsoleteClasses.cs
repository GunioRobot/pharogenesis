obsoleteClasses   "Smalltalk obsoleteClasses inspect"
	"NOTE:  Also try inspecting comments below"
	| obs c |
	obs _ OrderedCollection new.  Smalltalk garbageCollect.
	Metaclass allInstances do:
		[:m | c _ m soleInstance.
		(c ~~ nil and: ['AnOb*' match: c name asString])
			ifTrue: [obs add: c]].
	^ obs asArray

"Likely in a ClassDict or Pool...
(Association allInstances select: [:a | (a value isKindOf: Class) and: ['AnOb*' match: a value name]]) asArray
"
"Obsolete class refs or super pointer in last lit of a method...
| n l found |
Smalltalk browseAllSelect:
	[:m | found _ false.
	1 to: m numLiterals do:
		[:i | (((l _ m literalAt: i) isMemberOf: Association)
				and: [(l value isKindOf: Behavior)
				and: ['AnOb*' match: l value name]])
			ifTrue: [found _ true]].
	found]
"