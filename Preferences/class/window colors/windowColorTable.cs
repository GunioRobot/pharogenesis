windowColorTable
	"Answer a list of WindowColorSpec objects, one for each tool to be represented in the window-color panel"
	
	^ (((self systemNavigation allClassesImplementing: #windowColorSpecification) collect:
		[:aClass | aClass theNonMetaClass windowColorSpecification]) asSortedCollection:
			[:specOne :specTwo | specOne wording < specTwo wording]) asArray

"Preferences windowColorTable"