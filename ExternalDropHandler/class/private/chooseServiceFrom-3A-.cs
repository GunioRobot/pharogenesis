chooseServiceFrom: aCollection
	"private - choose a service from aCollection asking the user if  
	needed"
	| menu |
	aCollection size = 1
		ifTrue: [^ aCollection anyOne].
	""
	menu := CustomMenu new.
	aCollection
		do: [:each | menu add: each label action: each].
	^ menu startUp