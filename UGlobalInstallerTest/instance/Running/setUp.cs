setUp
	| package |
	universe _ UStandardUniverse new.
	
	package _ UPackage new.
	package name: 'A'.
	package addDependency: 'B'.
	universe addPackage: package.
	
	package _ UPackage new.
	package name: 'B'.
	package addDependency: 'C'.
	universe addPackage: package.
	
	package _ UPackage new.
	package name: 'C'.
	package addDependency: 'D'.
	package addDependency: 'E'.
	universe addPackage: package.
	
	package _ UPackage new.
	package name: 'D'.
	universe addPackage: package.
	
	package _ UPackage new.
	package name: 'E'.
	universe addPackage: package.

	package _ UPackage new.
	package name: 'Broken'.
	package addDependency: 'NonExistent'.
	universe addPackage: package.
	
