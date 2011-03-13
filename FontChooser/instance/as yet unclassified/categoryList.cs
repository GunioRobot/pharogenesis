categoryList
	^OrderedCollection new
		"add:  self allCategoryLabel;
		addAll: preferences categoryNames asSortedCollection;
		add: self searchResultsCategoryLabel;"
		addAll: (TextStyle actualTextStyles keysSortedSafely);
		yourself.