buildViewsFor: model 
	"Answer a collection of window panes for the Celeste user interface."
	| textViewClass listFont views v |

	textViewClass _ PluggableTextView.
	listFont _ (TextStyle named: #DefaultFixedTextStyle) defaultFont.
	views _ OrderedCollection new.
	v _ PluggableListViewByItem
				on: model
				list: #categoryList
				selected: #category
				changeSelected: #setCategory:
				menu: #categoryMenu:
				keystroke: #categoriesKeystroke:.
	views add: v.
	v _ PluggableListView
				on: model
				list: #tocEntryListAsStrings
				selected: #tocIndex
				changeSelected: #setTOCIndex:
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