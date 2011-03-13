buildViewsFor: model 
	"Answer a collection of window panes for the Celeste user interface."
	| listViewClass textViewClass listFont views v multiListViewClass |
	listViewClass _ PluggableListViewByItem.
	multiListViewClass _ PluggableListViewByItem.
	textViewClass _ PluggableTextView.
	listFont _ StrikeFont allSubInstances
				detect: [:f | (f name beginsWith: 'CourierFixed')
						and: [f height = 11]]
				ifNone: [TextStyle defaultFont].
	views _ OrderedCollection new.
	v _ listViewClass
				on: model
				list: #categoryList
				selected: #category
				changeSelected: #setCategory:
				menu: #categoryMenu:
				keystroke: #categoriesKeystroke:.
	views add: v.
	v _ multiListViewClass
				on: model
				list: #tocEntryList
				selected: #tocEntry
				changeSelected: #setTOCEntry:
				menu: #tocMenu:
				keystroke: #tocKeystroke:.
	v font: listFont.
	views add: v.
	v _ textViewClass new
				on: model
				text: #messageText
				accept: #messageText:
				readSelection: nil
				menu: #messageMenu:shifted:.
	v borderWidth: 1.
	model messageTextView: v.
	views add: v.
	v _ textViewClass new
				on: model
				text: #status
				accept: nil
				readSelection: nil
				menu: nil.
	v borderWidth: 1.
	model messageTextView: v.
	views add: v.
	^ views