fullRepaintNeeded

	self damageRecorder doFullRepaint.
	SystemWindow windowsIn: self
		satisfying: [:w | w makeMeVisible. false].

