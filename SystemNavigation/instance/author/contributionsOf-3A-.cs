contributionsOf: aString
	"SystemNavigation default contributionsOf: 'alain.plantec'"
	
	| stamp initials answer |
	answer := OrderedCollection new.
	self allBehaviorsDo: [ :behavior |
		behavior methodsDo: [ :compiledMethod |
			stamp := compiledMethod timeStamp.
			stamp notEmpty ifTrue: [
				initials := compiledMethod timeStamp substrings first.
				aString = initials ifTrue: [
					answer add: (compiledMethod selector -> compiledMethod methodClass)]]]].
	^answer