oldFileOrNoneNamed: fileName
	"If the file exists, answer a read-only FileStream on it. If it doesn't, answer nil."

	^ FileStream oldFileOrNoneNamed: fileName
