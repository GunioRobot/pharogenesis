startDownloadingMorphState: morphs
	downloadingProcess _ [
		morphs do: [ :m | m downloadStateIn: self].
	] newProcess.
	downloadingProcess resume.