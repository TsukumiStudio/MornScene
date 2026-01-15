# MornScene

## 概要

シーン管理と履歴ロールバック機能を提供するユーティリティライブラリ。

## 依存関係

| 種別 | 名前 |
|------|------|
| 外部パッケージ | Arbor（オプション: USE_ARBOR定義時） |
| Mornライブラリ | MornEnum, MornGlobal |

## 使い方

### 基本的なシーン切り替え

```csharp
// MornSceneTypeで型安全なシーン指定
MornSceneType sceneType = /* 設定されたシーン */;

// グローバル設定からシーンオブジェクトを取得
MornSceneObject sceneObject = sceneType.ToScene();

// SceneManagerで使用
SceneManager.LoadScene(sceneObject);
```

### ロールバック機能

```csharp
// シーン遷移時にロールバックキーを登録
MornSceneService.I.RegisterRollbackScene(key, currentScene);

// 後で以前のシーンに戻す
if (MornSceneService.I.TryGetRollbackScene(key, out var sceneName))
{
    SceneManager.LoadSceneAsync(sceneName, loadMode);
}
```

### Arborステート（USE_ARBOR定義時）

| ステート | 機能 |
|---------|------|
| ChangeSceneState | シーンを切り替え |
| AddSceneState | シーンを追加ロード |
| RollbackSceneState | ロールバック機能を使用 |
| RegisterRollbackSceneState | 現在のシーンをロールバック用に登録 |
| UnLoadSceneState | シーンをアンロード |
| ReloadSceneState | シーンをリロード |
