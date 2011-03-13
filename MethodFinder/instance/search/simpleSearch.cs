simpleSearch
	"Run through first arg's class' selectors, looking for one that works."

| class supers listOfLists |
self exceptions.
class _ thisData first first class.
"Cache the selectors for the receiver class"
(class == cachedClass and: [cachedArgNum = ((argMap size) - 1)]) 
	ifTrue: [listOfLists _ cachedSelectorLists]
	ifFalse: [supers _ class withAllSuperclasses.
		listOfLists _ OrderedCollection new.
		supers do: [:cls |
			listOfLists add: (cls selectorsWithArgs: (argMap size) - 1)].
		cachedClass _ class.
		cachedArgNum _ (argMap size) - 1.
		cachedSelectorLists _ listOfLists].
listOfLists do: [:selectorList |
	selectorList do: [:aSel |
		(selector includes: aSel) ifFalse: [
			((Approved includes: aSel) or: [AddAndRemove includes: aSel]) ifTrue: [
				(self testPerfect: aSel) ifTrue: [
					selector add: aSel.
					expressions add: (String streamContents: [:strm | 
						strm nextPutAll: 'data', argMap first printString.
						aSel keywords doWithIndex: [:key :ind |
							strm nextPutAll: ' ',key.
							(key last == $:) | (key first isLetter not)
								ifTrue: [strm nextPutAll: ' data', 
									(argMap at: ind+1) printString]]])
					]]]]].
