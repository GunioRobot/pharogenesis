createStatusbar
	"create the statusbar for the receiver"
	| statusbar |
	statusbar := self createRow.
	statusbar addMorph: ((UpdatingStringMorph on: self selector: #status) growable: true;
			 useStringFormat;
			 hResizing: #spaceFill;
			 stepTime: 2000).
	^ statusbar