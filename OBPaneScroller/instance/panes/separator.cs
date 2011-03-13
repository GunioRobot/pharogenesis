separator
	^ BorderedSubpaneDividerMorph vertical 
		borderWidth: self separatorWidth / 2;
		color: model defaultBackgroundColor duller;
		borderRaised.