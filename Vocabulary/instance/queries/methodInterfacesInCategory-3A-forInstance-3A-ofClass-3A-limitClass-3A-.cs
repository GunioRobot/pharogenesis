methodInterfacesInCategory: categoryName forInstance: anObject ofClass: aClass limitClass: aLimitClass
	"Answer a list of method interfaces of all methods in the given category, provided they are implemented no further away than aLimitClass."

	| defClass |
	^ ((self allMethodsInCategory: categoryName forInstance: anObject ofClass: aClass) collect:
		[:sel | methodInterfaces at: sel ifAbsent:
			[MethodInterface new conjuredUpFor: sel class: aClass]]) select:
				[:aMethodInterface |
					defClass _ aClass whichClassIncludesSelector: aMethodInterface selector.
					(defClass notNil and: [defClass includesBehavior: aLimitClass])]