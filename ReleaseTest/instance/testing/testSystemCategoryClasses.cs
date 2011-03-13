testSystemCategoryClasses
"Find cases where system categories name absent classes.
This test will tell you the classes.
This is inspired by a bug in release of 3.10.1 
see Mantis #7070" 
|  rejectCats rejectClasses | 
rejectCats := 
SystemOrganization categories reject: [ :catName |
	(SystemOrganization listAtCategoryNamed: catName) 
		allSatisfy: [ :className | 
			( Smalltalk includesKey: className ) ] ] .
"self assert: rejectCats isEmpty ."

rejectCats isEmpty ifTrue: [ ^ true ] . 


rejectClasses :=
rejectCats collect: [ :each |
	each ->
	( (SystemOrganization listAtCategoryNamed: each) 
		reject: [ :eachOne | 
			( Smalltalk includesKey: eachOne )  ] ) ] .

self assert: rejectCats isEmpty .
