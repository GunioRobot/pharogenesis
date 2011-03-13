buildWith: aBuilder
	^ aBuilder build: (aBuilder pluggableWindowSpec new
		model: self; 
		label: self label; 
		extent: self extent;
		closeAction: #close;
		children: (OrderedCollection new
			add: (aBuilder pluggableListSpec new
				model: self;
				list: #announcements;
				menu: #buildMenu:;
				getIndex: #index;
				setIndex: #index:;
				frame: (0 @ 0 corner: 1 @ 1);
				yourself);
			yourself);
		yourself)