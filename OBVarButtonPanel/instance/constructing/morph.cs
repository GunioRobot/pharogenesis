morph
	^ morph _ (RectangleMorph new)
					layoutPolicy: TableLayout new;
					listDirection: #leftToRight;
					hResizing: #spaceFill;
					vResizing: #spaceFill;
					borderWidth: 0;
					wrapCentering: #center;
					cellPositioning: #leftCenter;
					rubberBandCells: true;
					yourself