addMVCViews: views andButtons: buttons to: topWindow 
	(views at: 1)
		window: (0 @ 0 extent: 20 @ 25).
	(views at: 2)
		window: (0 @ 0 extent: 80 @ 25).
	(views at: 3)
		window: (0 @ 0 extent: 100 @ 70).
	(buttons at: 1)
		window: (0 @ 0 extent: 12 @ 5).
	(buttons at: 2)
		window: (0 @ 0 extent: 12 @ 5).
	(buttons at: 3)
		window: (0 @ 0 extent: 12 @ 5).
	(buttons at: 4)
		window: (0 @ 0 extent: 10 @ 5).
	(buttons at: 5)
		window: (0 @ 0 extent: 13 @ 5).
	(buttons at: 6)
		window: (0 @ 0 extent: 13 @ 5).
	(buttons at: 7)
		window: (0 @ 0 extent: 15 @ 5).
	(buttons at: 8)
		window: (0 @ 0 extent: 13 @ 5).
	topWindow
		addSubView: (buttons at: 1);
		
		addSubView: (buttons at: 2)
		toRightOf: (buttons at: 1);
		
		addSubView: (buttons at: 3)
		toRightOf: (buttons at: 2);
		
		addSubView: (buttons at: 4)
		toRightOf: (buttons at: 3);
		
		addSubView: (buttons at: 5)
		toRightOf: (buttons at: 4);
		
		addSubView: (buttons at: 6)
		toRightOf: (buttons at: 5);
		
		addSubView: (buttons at: 7)
		toRightOf: (buttons at: 6);
		
		addSubView: (buttons at: 8)
		toRightOf: (buttons at: 7);
		
		addSubView: (views at: 1)
		below: (buttons at: 1);
		
		addSubView: (views at: 2)
		toRightOf: (views at: 1);
		
		addSubView: (views at: 3)
		below: (views at: 1)