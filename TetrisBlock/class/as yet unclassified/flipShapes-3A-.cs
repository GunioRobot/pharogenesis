flipShapes: anArray

	^OrderedCollection new 
		add: anArray;
		add: (anArray collect: [ :each | each y negated @ each x]);
		add: (anArray collect: [ :each | each x negated @ each y negated]);
		add: (anArray collect: [ :each | each y @ each x negated]);
		yourself
	
