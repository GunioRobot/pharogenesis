describeCategoriesOn: aStream indent: tabs 
	"Show a full listing of categories and their dscription on aStream, indented by the given number of tabs."

	categories isEmptyOrNil
		ifFalse: [aStream cr;
				withAttribute: TextEmphasis bold
				do: [aStream nextPutAll: 'Categories: ']; cr.
			(self categories asSortedCollection: [:a :b | a path < b path])
				do: [:c | 
					aStream tab: tabs.
					c
						parentsDo: [:p | aStream nextPutAll: p name;
								 nextPut: $/].
					aStream nextPutAll: c name;
						 nextPutAll: ' - ';
						
						withAttributes: {TextEmphasis italic. TextIndent tabs: tabs + 1 }
						do: [aStream nextPutAll: c summary];
						 cr]]