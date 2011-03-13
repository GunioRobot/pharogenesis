refactoring
	"Create a Gofer instance of the refactoring tools."

	^ self new
		squeaksource: 'AST';
		addPrefix: 'AST-lr';
		squeaksource: 'RefactoringEngine'; 
		addPrefix: 'Refactoring-Core-lr';
		addPrefix: 'Refactoring-Spelling-lr';
		yourself