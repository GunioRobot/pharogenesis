memberMenu: menu shifted: shifted
	| services |

	menu
		add: 'Comment archive' target: self selector: #commentArchive;
		balloonTextForLastItem: 'Add a comment for the entire archive'.

	self selectedMember ifNotNilDo: [ :member |
		menu
			addLine;
			add: 'Inspect member' target: self selector: #inspectMember;
			balloonTextForLastItem: 'Inspect the selected member';
			add: 'Comment member' target: self selector: #commentMember;
			balloonTextForLastItem: 'Add a comment for the selected member';
			addLine.
		services := FileList itemsForFile: member fileName.
		menu addServices2: services for: self extraLines: #().
	].


	^menu