initializeFromTable: aTable
	"Initialize the receiver from a list of method-specification tuples, each of the form:
		(1)	selector
		(2)	companion setter selector (#none or nil indicate none)
		(3)  argument specification array, each element being an array of the form
				<arg name>  <arg type>
		(4)  result type, (#none or nil indicate none)
		(5)  array of category symbols, i.e. the categories in which this element should appear.
		(6)  help message. (optional)
		(7)  wording (optional)
		(8)  auto update flag (optional) - if #updating, set readout to refetch automatically

	Consult Vocabulary class.initializeTestVocabulary for an example of use"
				
	|  aMethodCategory categoryList aMethodInterface aSelector doc wording |
	categoryList _ Set new.
	aTable do:
		[:tuple | categoryList addAll: tuple fifth].
	categoryList _ categoryList asSortedArray.
	categoryList do:
		[:aCategorySymbol |
			aMethodCategory _ ElementCategory new categoryName: aCategorySymbol.
			aTable do:
				[:tuple | (tuple fifth includes: aCategorySymbol) ifTrue:
					[aMethodInterface _ MethodInterface new.
					aSelector _ tuple first.
					aMethodInterface selector: aSelector type: tuple fourth setter: tuple second.
					aMethodCategory elementAt: aSelector put: aMethodInterface.
					self atKey: aSelector putMethodInterface: aMethodInterface.
					((tuple third ~~ #none) and: [tuple third isEmptyOrNil not])
						ifTrue:
							[aMethodInterface argumentVariables: (tuple third collect:
								[:pair | Variable new name: pair first type: pair second])].
					doc _ (tuple size >= 6 and: [(#(nil none unused) includes: tuple sixth) not])
						ifTrue:
							[tuple sixth]
						ifFalse:
							[nil].
 					wording _ (tuple size >= 7 and: [(#(nil none unused) includes: tuple seventh) not])
						ifTrue:
							[tuple seventh]
						ifFalse:
							[aSelector asString].
					aMethodInterface
						wording: wording;
						helpMessage: doc.
					tuple size >= 8 ifTrue:
						[aMethodInterface setToRefetch]]].
			self addCategory: aMethodCategory]