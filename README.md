# TSV 資料檔讀取工具

## 專案介紹

本專案以 C# Windows Forms 開發的桌面應用程式，用於讀取並顯示 TSV 格式的單字資料檔。

系統介面如下:

<img width="1280" height="764" alt="image" src="https://github.com/user-attachments/assets/d9fd7e84-67cb-459b-a273-40e75594f8ca" />


---

## 功能特色

- 開啟並解析 `.txt` 或 `.tsv` 格式的單字資料檔
- 以清單方式顯示單字、音標、音檔路徑與解釋
- 狀態列即時顯示載入筆數與操作提示
- 關閉視窗前確認提示，防止誤關

即時顯示載入筆數與操作提示:

<img width="92" height="20" alt="image" src="https://github.com/user-attachments/assets/a5d5c34b-7271-4dd1-aeea-52f0171653fa" />


關閉視窗前確認提示:

<img width="178" height="122" alt="image" src="https://github.com/user-attachments/assets/026b62dc-ac37-4ada-9e16-116004880d02" />

---

## 畫面說明

| 欄位 | 說明 |
|------|------|
| 單字 | 英文單字 |
| 音標 | 音標標記 |
| 音檔路徑 | 對應音檔的路徑 |
| 解釋 | 中文解釋（支援多行） |

---

## TSV 檔案格式

每一行代表一筆單字資料，欄位之間以 **Tab (`\t`)** 分隔：

```
單字[Tab]音標[Tab]音檔路徑[Tab]解釋（可多欄）
```

範例：
```
apple	/ˈæp.əl/	sounds/apple.mp3	蘋果
book	/bʊk/	sounds/book.mp3	書；書本
run	/rʌn/	sounds/run.mp3	跑；奔跑	（動詞）
```

> 若解釋欄位有多個 Tab 分隔的內容，將自動以換行合併顯示。

---

## 操作流程

1. 執行程式後，點選選單 **File → Open**（或按 `Ctrl+O`）。
2. 選擇符合格式的 `.txt` 或 `.tsv` 檔案。
3. 單字資料將顯示於清單中，狀態列顯示載入筆數。

### 選單快捷鍵

| 選單項目 | 快捷鍵 |
|----------|--------|
| Open（開啟檔案） | `Ctrl+O` |
| Exit（離開） | `Ctrl+E` |
| About（關於） | `Ctrl+A` |

---

## 類別說明

### `WordItem`
單字資料的資料模型，解析單行 TSV 字串並對應至各個屬性。

### `WordCollection`
繼承自 `Collection<WordItem>`，提供 `LoadFromStringArray(string[] lines)` 方法，可批次解析整份檔案內容。

### `frmAbout`
關於視窗，顯示本專案版本及開發者相關資訊

<img width="328" height="218" alt="image" src="https://github.com/user-attachments/assets/b95dff14-9210-493e-b2c8-49992630b29a" />

---
