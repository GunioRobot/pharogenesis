selectorMenu
	"Put up a menu of all selectors that my receiver could be sent.  Replace me with the one chosen.  (If fewer args, put the tiles for the extra arg to the side, in script's owner (world?).)
	Go ahead and eval receiver to find out its type.  Later, mark selectors for side effects, and don't eval those.
	Put up a table.  Each column is a viewer category."

	| cats value catNames interfaces list setter wording all words ind aVocabulary limitClass |
	cats _ #().
	all _ Set new.
	value _ self receiverObject.
	value class == Error ifTrue: [^ nil].
	
	aVocabulary _ self vocabularyToUseWith: value.
	limitClass _ self limitClassToUseWith: value vocabulary: aVocabulary.
	catNames _ value categoriesForVocabulary: aVocabulary limitClass: limitClass.
	cats _ catNames collect: [:nn | 
		list _ OrderedCollection new.
		interfaces _ value methodInterfacesForCategory: nn 
						inVocabulary: aVocabulary limitClass: limitClass.
		interfaces do: [:mi | 
			(all includes: mi selector) ifFalse: [
				"list add: (self aSimpleStringMorphWith: mi elementWording).  Expensive"
				words _ mi selector.
				(words beginsWith: 'get ') ifTrue: [words _ words allButFirst: 4].
				mi selector last == $: ifTrue: [
					words _ String streamContents: [:strm | "add fake args"
						(words findTokens: $:) do: [:part | strm nextPutAll: part; nextPutAll: ' 5 ']].
					words _ words allButLast].
				mi selector isInfix ifTrue: [words _ words, ' 5'].
				words _ self splitAtCapsAndDownshifted: words.	
				list add: (self anUpdatingStringMorphWith: words special: true).
				words = mi selector ifFalse: [
					list last setProperty: #syntacticallyCorrectContents toValue: mi selector].
				all add: mi selector].
			setter _ mi companionSetterSelector asString.
			(setter = 'nil') | (all includes: setter) ifFalse: ["need setters also"
				wording _ (self translateToWordySetter: setter).
				list add:  (self aSimpleStringMorphWith: wording, ' 5').
				wording = setter ifFalse: [
					list last setProperty: #syntacticallyCorrectContents 
						toValue: setter].
				all add: setter]].
		list].
	(ind _ catNames indexOf: 'scripts') > 0 ifTrue: [
		(cats at: ind) first contents = 'empty script' ifTrue: [(cats at: ind) removeFirst]].
	cats first addFirst: (self aSimpleStringMorphWith: ' ').	"spacer"
	cats first addFirst: (self aSimpleStringMorphWith: '( from ', value class name, ' )').
	cats first first color: (Color green mixed: 0.25 with: Color black).
	self selectorMenuAsk: cats.	"The method replaceSel:menuItem: does the work.  
		and replaces the selector."
	