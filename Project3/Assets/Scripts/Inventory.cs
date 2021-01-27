using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//[CreateAssetMenu(menuName = "Inventory System/Database")]
public class Inventory : MonoBehaviour//ScriptableObject //
{

    public static Inventory instance = null;
    public string ID;
    public int turtleQuantity;
    public int coffQuantity;
    public int redBullQuantity;
    public int pillsQuantity;
    public int calculatorQuantity;
    public int ruleQuantity;
    public int compassQuantity;
    public int pencilQuantity;
    public int glassesQuantity;
    public int puzzleQuantity;
    public int bookQuantity;
    public int usbQuantity;
    public int cheatQuantity;
    public int coinsQuantity;

    public bool calcAch;
    public bool electronicsAch;
    public bool commsAch;
    public bool oescAch;
    public bool dsaAch;
    public bool aeroAch;
    public bool tfgAch;

    public Inventory() {
        instance = this;
    }
    public Inventory GetInventory() {
        return instance;
    }
    public void SetCalc(){
        this.calcAch=true;
    }
    public void SetElec(){
        this.electronicsAch=true;
    }
    public void SetComms(){
        this.commsAch=true;
    }
    public void SetOesc(){
        this.oescAch = true;
    }
    public void SetDsa()
    {
        this.dsaAch = true;
    }
    public void SetAero(){
        this.aeroAch = true;
    }
    public void SetTfg(){
        this.tfgAch = true;
    }
    public bool GetCalc(){
        return this.calcAch;
    }
    public bool GetElec(){
        return this.electronicsAch;
    }
    public bool GetComms(){
        return this.commsAch;
    }
    public bool GetOesc(){
        return this.oescAch;
    }
    public bool GetDsa(){
        return this.dsaAch;
    }
    public bool GetAero(){
        return this.aeroAch;
    }
    public bool GetTfg(){
        return this.tfgAch;
    }




    public void SetID(string text){
        this.ID=text;
    }
    public void SetTurtle(int q){
        this.turtleQuantity=q;
    }
    public void SetCoffee(int q){
        this.coffQuantity=q;
    }
    public void SetRedBull(int q){
        this.redBullQuantity=q;
    }
    public void SetPills(int q){
        this.pillsQuantity=q;
    }
    public void SetCalculator(int q){
        this.calculatorQuantity=q;
    }
    public void SetRule(int q){
        this.ruleQuantity=q;
    }
    public void SetCompass(int q){
        this.compassQuantity=q;
    }
    public void SetPencil(int q){
        this.pencilQuantity=q;
    }
    public void SetGlasses(int q){
        this.glassesQuantity=q;
    }
    public void SetUsb(int q){
        this.usbQuantity=q;
    }
    public void SetBook(int q){
        this.bookQuantity=q;
    }
    public void SetPuzzle(int q){
        this.puzzleQuantity=q;
    }
    public void SetCheat(int q){
        this.cheatQuantity=q;
    }
    public void SetCoins(int q){
        this.coinsQuantity=q;
    }

    public string GetID(){
        return this.ID;
    }
    public int GetTurtle(){
        return this.turtleQuantity;
    }
    public int GetCoffee(){
        return this.coffQuantity;
    }
    public int GetRedBull(){
        return this.redBullQuantity;
    }
    public int GetPills(){
        return this.pillsQuantity;
    }
    public int GetCalculator(){
        return this.calculatorQuantity;
    }
    public int GetRule(){
        return this.ruleQuantity;
    }
    public int GetCompass(){
        return this.compassQuantity;
    }
    public int GetPencil(){
        return this.pencilQuantity;
    }
    public int GetUsb(){
        return this.usbQuantity;
    }
    public int GetGlasses(){
        return this.glassesQuantity;
    }
    public int GetBook(){
        return this.bookQuantity;
    }
    public int GetPuzzle(){
        return this.puzzleQuantity;
    }
    public int GetCheat(){
        return this.cheatQuantity;
    }
    public int GetCoins(){
        return this.coinsQuantity;
    }

}