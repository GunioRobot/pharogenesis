testClassesSystemCategory
"Find cases where classes have nil system categories.
This test will tell you the classes.
This is inspired by the proposed fix of a bug in release of 3.10.1 
see Mantis #7070" 
| rejectClasses | 

rejectClasses := 
 nil systemNavigation allClasses reject: [ :each |
	each category notNil ] .


self assert: rejectClasses isEmpty .

