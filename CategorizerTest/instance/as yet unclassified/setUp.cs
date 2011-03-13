setUp
	categorizer := Categorizer defaultList: #(a b c d e).
	categorizer classifyAll: #(a b c) under: 'abc'.
	categorizer addCategory: 'unreal'.