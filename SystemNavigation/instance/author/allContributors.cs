allContributors
	"SystemNavigation default allContributors"
	
	| bag stamp |
	bag := Bag new.
	self allBehaviorsDo: [ :behavior |
		behavior methodsDo: [ :compiledMethod |
			stamp := compiledMethod timeStamp.
			stamp notEmpty ifTrue: [
				bag add: compiledMethod timeStamp substrings first ]]].
	^bag