updateFlaps
	Flaps globalFlapTabs
		select: [:each | each flapID = 'Supplies' translated]
		thenDo: [:each | 
			each
				color: (self normal: 1);
				
				borderColor: (self normal: 1);
				 borderWidth: (self menuBorderWidth).
			""
			each referent
				color: (self light: 1);
				 borderWidth: (self menuBorderWidth);
				
				borderColor: (self normal: 1)]