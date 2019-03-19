# EasySlugify

# Usage
```
"Garbiñe Muguruza".Slug()  // Garbiñe-Muguruza

"Garbiñe Muguruza".Slug().ReplaceDiacritics()  // Garbine-Muguruza

"Garbiñe Muguruza".Slug("_").ReplaceDiacritics()  // Garbine_Muguruza

"Garbiñe Muguruza".Slug("_").ReplaceDiacritics(new Dictionary<string, string>() { {"G","g"}, { "a", "A" } }) 
// gArbine_MuguruzA 
```

# License
MIT Copyright (c) Yu-Jean Chen
