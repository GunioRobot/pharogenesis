open: aChangeList name: aString 
	"Open a view for the changeList, with a multiple selection list. "
	^ self open: aChangeList name: aString
		withListView: (ListViewOfMany new controller: ChangeListController new)