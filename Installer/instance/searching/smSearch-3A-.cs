smSearch: aMatch  

	| results |
	
	results := Set new.

	self packages do: [ :pkg |
		({ 'name:',pkg name.
		   'summary:', pkg summary.
		   'description:', pkg description.
		   'author:', pkg author. } anySatisfy: [ :field | aMatch match: field ])
		 ifTrue: [ results add: (self copy package: pkg name) ]. 
	].

	^results

