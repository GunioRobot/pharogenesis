start: strt stop: stp
	minorTick: mnt minorTickLength: mntLen
	majorTick: mjt majorTickLength: mjtLen
	caption: cap tickPrintBlock: blk

	start _ strt.  stop _ stp.
	minorTick _ mnt.  minorTickLength _ mntLen.
	majorTick _ mjt.  majorTickLength _ mjtLen.
	caption _ cap.  tickPrintBlock_ blk fixTemps.
	self buildLabels