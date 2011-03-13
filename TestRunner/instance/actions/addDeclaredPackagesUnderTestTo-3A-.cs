addDeclaredPackagesUnderTestTo: packages 
	classesSelected do: 
		[ :class | 
		(class class selectors includes: #packageNamesUnderTest) ifTrue: 
			[ class packageNamesUnderTest do: [ :name | packages add: (PackageInfo named: name) ] ] ]