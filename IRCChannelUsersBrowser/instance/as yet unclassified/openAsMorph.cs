openAsMorph
	| win listView talkToButton |
	win _ SystemWindow labelled: 'users in ', channel name.
	win model: self.

	listView _ PluggableListMorph on: self list: #userList selected: #userIndex  changeSelected: #userIndex:.
	win addMorph: listView  frame: (0@0 extent: 1@0.9).

	talkToButton _ PluggableButtonMorph on: self getState: nil action: #talkTo.
	talkToButton label: 'talk to selected user'.
	win addMorph: talkToButton  frame: (0@0.9 extent: 1@0.1).

	win openInWorld