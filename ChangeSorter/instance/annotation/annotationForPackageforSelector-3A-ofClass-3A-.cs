annotationForPackageforSelector: aSelector ofClass: aClass 
	"Provide a line of content for an annotation pane, representing 
	information about the given selector and class"
	"requestList"
| aCategory |
aClass ifNil: [ ^nil] .
aSelector ifNil: [ aClass theNonMetaClass category asString ] .
aSelector ifNotNil: [ aCategory := aClass organization categoryOfElement: aSelector.
(aCategory notNil and: [ aCategory first = $* ]) 
	ifTrue: [^ aCategory asString]] .
	
"Ok. So the selector catagory does not indicate our package. We defer to the class catagory"

^ aClass theNonMetaClass category asString.
	