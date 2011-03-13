open
	"PluggableTest open"

	| model listView1 topView listView2 |
	model _ self new initialize.
	listView1 _
		PluggableListView on: model
			list: #musicTypeList
			selected: #musicType
			changeSelected: #musicType:
			menu: #musicTypeMenu:
			keystroke: #musicTypeKeystroke:.

	listView2 _
		PluggableListView on: model
			list: #artistList
			selected: #artist
			changeSelected: #artist:
			menu: nil
			keystroke: #artistKeystroke:.

	topView _ StandardSystemView new
		label: 'Pluggable Test';
		minimumSize: 300@200;
		borderWidth: 1;
		addSubView: listView1;
		addSubView: listView2 toRightOf: listView1.
	topView borderWidth: 1.
	topView controller open.