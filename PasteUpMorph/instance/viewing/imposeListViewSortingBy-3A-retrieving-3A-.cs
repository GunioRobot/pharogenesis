imposeListViewSortingBy: sortOrderSymbol retrieving: fieldListSelectors
	"Establish a list view of the receiver's contents, sorting the contents by the criterion represented by sortOrderSymbol, and displaying readouts as indicated by the list of field selectors."
	| rep |

	self setProperty: #sortOrder toValue: sortOrderSymbol.
	self setProperty: #fieldListSelectors toValue: fieldListSelectors.

	self showingListView ifFalse:
		[self autoLineLayout ifFalse: [self saveBoundsOfSubmorphs].
		self setProperty: #showingListView toValue: true.
		self layoutPolicy: TableLayout new.
		self layoutInset: 2; cellInset: 2.
		self listDirection: #topToBottom.
		self wrapDirection: #none].

	self submorphs "important that it be a copy" do:
		[:aMorph | 
			rep _ aMorph listViewLineForFieldList: fieldListSelectors.
			rep hResizing: #spaceFill.
			self replaceSubmorph: aMorph by: rep].

	self sortSubmorphsBy: (self valueOfProperty: #sortOrder).